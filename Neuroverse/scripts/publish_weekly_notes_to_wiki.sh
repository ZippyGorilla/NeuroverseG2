#!/bin/bash

# Clone wiki if not present
if [ ! -d "../Neuroverse.wiki" ]; then
  git clone https://github.com/Ziforge/Neuroverse.wiki.git ../Neuroverse.wiki
fi

cd ../Neuroverse.wiki

# Copy each weekly note into the wiki
for file in ../Neuroverse/weekly_notes/week*.md; do
  filename=$(basename -- "$file")
  weekname="${filename%.*}"
  title=$(echo "$weekname" | sed 's/week/Week-/' | sed 's/_/-/g')

  cp "$file" "${title}.md"
  echo "✅ Published $file to Wiki as ${title}.md"
done

# Commit and push
git add *.md
git commit -m "📝 Add or update weekly progress pages"
git push
