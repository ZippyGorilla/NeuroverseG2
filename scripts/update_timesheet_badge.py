import datetime

README_PATH = "README.md"
BADGE_START = "[![Weekly Timesheet]("

# Calculate current ISO week number
week_num = datetime.datetime.now().isocalendar().week
link = f"https://github.com/Ziforge/Neuroverse/blob/main/weekly_notes/week-{week_num}-timesheet.md"

badge = f"[![Weekly Timesheet](https://img.shields.io/badge/Open_This_Week's_Timesheet-blue?style=for-the-badge)]({link})"

# Update README.md
with open(README_PATH, "r") as f:
    lines = f.readlines()

with open(README_PATH, "w") as f:
    for line in lines:
        if BADGE_START in line:
            f.write(badge + "\n")
        else:
            f.write(line)

print(f"✅ README updated with badge linking to week {week_num} timesheet")
