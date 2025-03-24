#!/bin/bash

# Ensure you're in the wiki directory
cd ../Neuroverse.wiki || { echo "Wiki not found. Clone it first."; exit 1; }

SIDEBAR="_Sidebar.md"
echo "## 🧭 Wiki Navigation" > $SIDEBAR
echo "- [Home](Home)" >> $SIDEBAR
echo "- [Development Guide](Development-Setup-Guide)" >> $SIDEBAR
echo "- [Automation Script](Automation-Script)" >> $SIDEBAR

echo -e "\n## 📅 Weekly Progress" >> $SIDEBAR

# Scan for any Week-N-Progress.md files and link them
for file in Week-*-Progress.md; do
  [ -e "$file" ] || continue  # skip if no matching files
  name="${file%.md}"
  echo "- [${name//-/ }]("$name")" >> $SIDEBAR
done

git add $SIDEBAR
git commit -m "🔄 Auto-update _Sidebar.md with weekly progress links"
git push

echo "✅ Sidebar updated with weekly progress pages."

