name: 🔁 Update Timesheet Badge in README

on:
  schedule:
    - cron: '5 9 * * 1'  # Every Monday 09:05 UTC
  workflow_dispatch:

jobs:
  update-readme:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout repo
      uses: actions/checkout@v3

    - name: Set up Python
      uses: actions/setup-python@v4
      with:
        python-version: '3.10'

    - name: Update README badge
      run: |
        python3 scripts/update_timesheet_badge.py

    - name: Commit and push changes
      run: |
        git config user.name github-actions[bot]
        git config user.email github-actions[bot]@users.noreply.github.com
        git add README.md
        git commit -m \"🔁 Auto-update weekly timesheet badge\" || echo \"No changes to commit\"
        git push
