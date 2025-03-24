#!/bin/bash

source .env

REPO="Ziforge/Neuroverse"

# Replace with actual field IDs you got from API
TIME_ESTIMATE_FIELD_ID="PVTSSF_XXXXXXXXXX"  # ← update this
TIME_LOGGED_FIELD_ID="PVTSSF_YYYYYYYYYY"   # ← update this
CONTRIBUTOR_FIELD_ID="PVTSSF_ZZZZZZZZZZ"   # ← update this

# Simple estimates per week per group (customize as needed)
declare -A ESTIMATES=(
  ["Week 1|A"]=10
  ["Week 1|B"]=8
  ["Week 1|C"]=9
  ["Week 2|A"]=12
  ["Week 2|B"]=10
  ["Week 2|C"]=10
)

# Loop through Weeks and Groups
for WEEK in {1..2}; do
  for GROUP in A B C; do
    KEY="Week $WEEK|$GROUP"
    ESTIMATE=${ESTIMATES[$KEY]:-8}

    echo "⏱ Updating time fields for Week $WEEK - Group $GROUP (Estimate: $ESTIMATE hrs)"

    # Loop through matching issues (replace range or use API filter if available)
    for ISSUE_NUM in {1..24}; do
      echo "🔧 Updating Issue #$ISSUE_NUM..."

      ISSUE_NODE_ID=$(gh api graphql -f query='query($owner:String!, $name:String!, $number:Int!) {
        repository(owner:$owner, name:$name) {
          issue(number: $number) { id }
        }
      }' -F owner="Ziforge" -F name="Neuroverse" -F number=$ISSUE_NUM --jq '.data.repository.issue.id')

      # Set Time Estimate
      curl -s -X POST \
        -H "Authorization: bearer $GH_TOKEN" \
        -H "Content-Type: application/json" \
        -d "{\"query\":\"mutation {
          updateProjectV2ItemFieldValue(input: {
            projectId: \\\"$PROJECT_ID\\\",
            itemId: \\\"$ISSUE_NODE_ID\\\",
            fieldId: \\\"$TIME_ESTIMATE_FIELD_ID\\\",
            value: { text: \\\"$ESTIMATE\\\" }
          }) { projectV2Item { id } }
        }\"}" https://api.github.com/graphql

      # Set Time Logged to 0
      curl -s -X POST \
        -H "Authorization: bearer $GH_TOKEN" \
        -H "Content-Type: application/json" \
        -d "{\"query\":\"mutation {
          updateProjectV2ItemFieldValue(input: {
            projectId: \\\"$PROJECT_ID\\\",
            itemId: \\\"$ISSUE_NODE_ID\\\",
            fieldId: \\\"$TIME_LOGGED_FIELD_ID\\\",
            value: { text: \\\"0\\\" }
          }) { projectV2Item { id } }
        }\"}" https://api.github.com/graphql

    done
  done
done

echo "✅ Time fields initialized!"
