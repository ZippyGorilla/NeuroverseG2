#!/bin/bash

# Load environment variables
source .env

REPO="Ziforge/Neuroverse"
ISSUE_NUMBERS=({1..24}) # Adjust based on real issue numbers

for ISSUE_NUM in "${ISSUE_NUMBERS[@]}"; do
  echo "🔗 Linking Issue #$ISSUE_NUM to Project..."

  ISSUE_NODE_ID=$(gh api graphql -f query='query($owner:String!, $name:String!, $number:Int!) {
    repository(owner:$owner, name:$name) {
      issue(number:$number) { id }
    }
  }' -f owner="Ziforge" -f name="Neuroverse" -F number=$ISSUE_NUM --jq '.data.repository.issue.id')

  curl -s -X POST \
    -H "Authorization: bearer $GH_TOKEN" \
    -H "Content-Type: application/json" \
    -d '{"query": "mutation { addProjectV2ItemById(input: {projectId: \"'"$PROJECT_ID"'\", contentId: \"'"$ISSUE_NODE_ID"'\"}) { item { id } } }"}' \
    https://api.github.com/graphql

  echo "✅ Issue #$ISSUE_NUM linked"
done
