import pandas as pd
import scipy.stats as stats

# Load data
file_path = 'Test Data/TestDataGathered.xlsx'
sheet_name = 'AllAnswers'
df = pd.read_excel(file_path, sheet_name=sheet_name)
df.columns = df.columns.str.strip()

# Define the grouping column name exactly as in your data
group_col = 'PreQuest_Answers;What best describes your neurotype?'

# Clean grouping column: unify group labels
df[group_col] = df[group_col].astype(str).str.strip()

# Map neurotype labels to just two groups: 'ND' or 'Non-ND'
def map_group(val):
    val_lower = val.lower()
    if val_lower in ['neurotypical', 'none', 'non-nd', 'non nd', 'nonnd']:
        return 'Non-ND'
    else:
        return 'ND'

df[group_col] = df[group_col].apply(map_group)
df[group_col] = df[group_col].astype('category')

# Detect numeric columns by attempting conversion (keep columns with >50% numeric)
numeric_cols = []
for col in df.columns:
    converted = pd.to_numeric(df[col], errors='coerce')
    if converted.notna().sum() > len(df) / 2:
        numeric_cols.append(col)
        df[col] = converted  # replace with numeric version

# Remove grouping column from numeric tests
if group_col in numeric_cols:
    numeric_cols.remove(group_col)

# Run ANOVA on each numeric column grouped by 'group_col'
anova_results = {}
for col in numeric_cols:
    groups = [group[col].dropna() for name, group in df.groupby(group_col)]
    if len(groups) > 1:
        f_val, p_val = stats.f_oneway(*groups)
        anova_results[col] = (f_val, p_val)

# Print results
print(f"ANOVA results grouped by '{group_col}':\n")
if anova_results:
    for col, (f, p) in anova_results.items():
        print(f"{col}: F={f:.3f}, p={p:.4f}")
else:
    print("No numeric columns suitable for ANOVA found.")
