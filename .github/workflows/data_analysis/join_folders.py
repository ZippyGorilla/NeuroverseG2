import pandas as pd

# Load your Excel files
pre_df = pd.read_excel('pre.xlsx')    # Replace with actual path
post_df = pd.read_excel('post.xlsx')  # Replace with actual path

# Inspect columns (optional)
print(pre_df.columns)
print(post_df.columns)

# Merge on 'Participant number' column (adjust name if needed)
merged_df = pd.merge(pre_df, post_df, on='Participant number', suffixes=('_pre', '_post'))

# View the combined dataframe
print(merged_df.head())