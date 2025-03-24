#!/bin/bash

source .env

REPO="Ziforge/Neuroverse"

STATUS_FIELD="PVTSSF_lAHOCt5hsc4A1EqczgqmhT8"
STATUS_TODO="f75ad846"

WEEK_FIELD="PVTSSF_lAHOCt5hsc4A1Eqczgqmy9Q"
WEEK_ID="6860af6e"  # Week 1

GROUP_FIELD="PVTSSF_lAHOCt5hsc4A1EqczgqmzJs"
declare -A GROUP_IDS=(
  [A]="3f82e051"
  [B]="83fa5c6f"
  [C]="8607f2c4"
)

# Manually define Week 1 issues
declare -A ISSUE_MAP=(
  [1]="A"
  [2]="B"
  [3]="C"
)

for ISSUE_NUM in "${!ISSUE_MAP[@]}"; do
  GROUP_KEY=${ISSUE_MAP[$ISSUE_NUM]}
  echo "🔗 Linking and assigning Issue #$ISSUE_NUM (Group $GROUP_KEY, Week 1)..."

  ISSUE_NODE_ID=$(gh api graphql -f query='query($owner:String!, $name:String!, $number:Int!) {
    repository(owner:$owner, name:$name) {
      issue(number: $number) { id }
    }
  }' -F owner="Ziforge" -F name="Neuroverse" -F number=$ISSUE_NUM --jq '.data.repository.issue.id')

  ITEM_ID=$(curl -s -X POST \
    -H "Authorization: bearer $GH_TOKEN" \
    -H "Content-Type: application/json" \
    -d '{"query": "mutation { addProjectV2ItemById(input: {projectId: \"'"$PROJECT_ID"'\", contentId: \"'"$ISSUE_NODE_ID"'\"}) { item { id } } }"}' \
    https://api.github.com/graphql | jq -r '.data.addProjectV2ItemById.item.id')

  # Set Status
  curl -s -X POST \
    -H "Authorization: bearer $GH_TOKEN" \
    -H "Content-Type: application/json" \
    -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: {projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$STATUS_FIELD"'\", value: { singleSelectOptionId: \"'"$STATUS_TODO"'\" }}) { projectV2Item { id } } }"}' \
    https://api.github.com/graphql

  # Set Week
  curl -s -X POST \
    -H "Authorization: bearer $GH_TOKEN" \
    -H "Content-Type: application/json" \
    -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: {projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$WEEK_FIELD"'\", value: { singleSelectOptionId: \"'"$WEEK_ID"'\" }}) { projectV2Item { id } } }"}' \
    https://api.github.com/graphql

  # Set Group
  curl -s -X POST \
    -H "Authorization: bearer $GH_TOKEN" \
    -H "Content-Type: application/json" \
    -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: {projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$GROUP_FIELD"'\", value: { singleSelectOptionId: \"'"${GROUP_IDS[$GROUP_KEY]}"'\" }}) { projectV2Item { id } } }"}' \
    https://api.github.com/graphql

  echo "✅ Issue #$ISSUE_NUM updated."
done
