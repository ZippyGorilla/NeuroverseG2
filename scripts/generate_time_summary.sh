#!/bin/bash

mkdir -p summary
OUTPUT="summary/weekly-time-summary.md"

echo "# 🧾 Neuroverse Weekly Time Summary" > $OUTPUT

echo -e "\n| Week | Name | Estimated (hrs) | Logged (hrs) | Deviation |" >> $OUTPUT
echo "|------|------|------------------|---------------|-----------|" >> $OUTPUT

for FILE in weekly_notes/week-*-timesheet.md; do
  WEEK=$(echo "$FILE" | grep -oP 'week-(\\d+)' | cut -d'-' -f2)
  tail -n +6 "$FILE" | while IFS='|' read -r _ NAME GROUP TASK EST LOGGED _; do
    NAME=$(echo "$NAME" | xargs)
    EST=$(echo "$EST" | xargs)
    LOGGED=$(echo "$LOGGED" | xargs)

    if [[ "$NAME" == "Name" || -z "$NAME" ]]; then
      continue
    fi

    if [[ "$EST" =~ ^[0-9.]+$ && "$LOGGED" =~ ^[0-9.]+$ ]]; then
      DEV=$(awk "BEGIN {printf \"%.1f\", $LOGGED - $EST}")
    else
      DEV="-"
    fi

    echo "| Week $WEEK | $NAME | $EST | $LOGGED | $DEV |" >> $OUTPUT
  done
done

echo "✅ Time summary written to $OUTPUT"
