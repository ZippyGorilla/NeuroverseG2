import os
import pandas as pd
import matplotlib.pyplot as plt
from glob import glob

# Config
WEEKLY_NOTES_DIR = "./weekly_notes"
SUMMARY_DIR = "./summary"
TOTAL_TARGET_HOURS = 350

os.makedirs(SUMMARY_DIR, exist_ok=True)

def parse_timesheet(file_path):
    df = pd.read_csv(file_path, sep='|', engine='python', skiprows=5)
    df = df.dropna(how='all', axis=1)
    df.columns = [col.strip() for col in df.columns]
    df = df[[col for col in df.columns if col.strip()]]
    df = df.dropna()
    df['Week'] = int(file_path.split('-')[-2])
    return df[['Name', 'Time Logged (hrs)', 'Week']].rename(columns={"Time Logged (hrs)": "Hours"})

# Combine all weeks
dataframes = []
for path in glob(f"{WEEKLY_NOTES_DIR}/week-*-timesheet.md"):
    try:
        df = parse_timesheet(path)
        dataframes.append(df)
    except Exception as e:
        print(f"Skipping {path}: {e}")

total_df = pd.concat(dataframes)

# Calculate total per person
total_hours = total_df.groupby("Name")["Hours"].sum().sort_values(ascending=False)
total_hours.to_csv(f"{SUMMARY_DIR}/individual_totals.csv")

# Plot total hours bar chart
plt.figure(figsize=(10, 6))
total_hours.plot(kind='barh', color='skyblue')
plt.title('Total Time Logged by Contributor')
plt.xlabel('Hours')
plt.ylabel('Team Member')
plt.tight_layout()
plt.savefig(f"{SUMMARY_DIR}/time_logged_bar_chart.png")

# Plot percent complete (based on 350 hrs target)
percent = (total_hours / TOTAL_TARGET_HOURS) * 100
plt.figure(figsize=(10, 6))
percent.plot(kind='barh', color='limegreen')
plt.title('Percent of 350hr Target Logged')
plt.xlabel('% Complete')
plt.xlim(0, 100)
plt.tight_layout()
plt.savefig(f"{SUMMARY_DIR}/percent_complete_chart.png")

print("✅ Visual summaries generated in ./summary/")
