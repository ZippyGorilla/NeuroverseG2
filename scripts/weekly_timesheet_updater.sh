#!/bin/bash

# Automate Weekly Timesheet Update (Markdown-based)
TEAM_MEMBERS=("George:A" "Anna:A" "Alex:B" "Size:B" "Adam:C" "August:C")
WEEK_NUMBER=$(date +%U) # override manually if needed
NOTES_DIR="./weekly_notes"
FILE="$NOTES_DIR/week-$WEEK_NUMBER-timesheet.md"

mkdir -p "$NOTES_DIR"

cat <<EOF > "$FILE"
# ⏱️ Neuroverse Weekly Timesheet – Week $WEEK_NUMBER

| Name    | Group | Task                    | Time Est. (hrs) | Time Logged (hrs) |
|---------|-------|-------------------------|------------------|--------------------|
EOF

for MEMBER in "${TEAM_MEMBERS[@]}"; do
  NAME="$(cut -d':' -f1 <<< "$MEMBER")"
  GROUP="$(cut -d':' -f2 <<< "$MEMBER")"
  echo "| $NAME | $GROUP | _TBD_ | _TBD_ | _TBD_ |" >> "$FILE"
done

echo "✅ Created/updated: $FILE"
