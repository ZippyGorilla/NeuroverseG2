import datetime

README_PATH = "README.md"
BADGE_START = "[![Weekly Timesheet]("

# Define ISO week your project starts (e.g. ISO week 13 is Week 1 of project)
PROJECT_START_ISO_WEEK = 13
MAX_PROJECT_WEEKS = 8

# Get today's ISO week number
current_iso_week = datetime.date.today().isocalendar().week

# Calculate project-relative week number
project_week = current_iso_week - PROJECT_START_ISO_WEEK + 1

# Only proceed if we're within the project timeline (1–8)
if 1 <= project_week <= MAX_PROJECT_WEEKS:
    timesheet_filename = f"week-{current_iso_week}-timesheet.md"
    link = f"https://github.com/Ziforge/Neuroverse/blob/main/weekly_notes/{timesheet_filename}"
    badge = f"[![Weekly Timesheet](https://img.shields.io/badge/Open_Week_{project_week}_Timesheet-blue?style=for-the-badge)]({link})"

    with open(README_PATH, "r") as f:
        lines = f.readlines()

    with open(README_PATH, "w") as f:
        for line in lines:
            if BADGE_START in line:
                f.write(badge + "\n")
            else:
                f.write(line)

    print(f"✅ README updated with badge linking to ISO week {current_iso_week} (Project Week {project_week})")
else:
    print(f"🛑 Outside of active project weeks (Week {project_week}). Badge not updated.")
