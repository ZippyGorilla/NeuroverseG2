import pandas as pd
from statsmodels.multivariate.manova import MANOVA

# Placeholder variables for group data (replace with real data later)
group1 = "data1"
group2 = "data2"
group3 = "data3"
group4 = "data4"

def extract_prequestionnaire_data(group):
    return group[0:10]  # Replace with actual extraction logic

def extract_vr_data(group):
    return group[10:20]  # Replace with actual extraction logic

def extract_postquestionnaire_data(group):
    return group[20:30]  # Replace with actual extraction logic

def perform_manova(data1, data2):
    """
    Expects 4 lists of dictionaries (or similar), each representing a group,
    with consistent keys for dependent variables (e.g., 'reverb', 'saturation').
    """
    # Convert all data into a unified DataFrame
    all_data = []
    vrdata1 = extract_vr_data(data1)
    vrdata2 = extract_vr_data(data2)
    for i, group_data in enumerate([vrdata1, vrdata2]):
        group_name = ['Neurotypical', 'Neurodiverse'][i]
        for entry in group_data:
            entry_copy = entry.copy()  # Prevent mutation
            entry_copy['group'] = group_name
            all_data.append(entry_copy)

    df = pd.DataFrame(all_data)

    # Build MANOVA formula dynamically
    dependent_vars = [col for col in df.columns if col != 'group']
    formula = f"{' + '.join(dependent_vars)} ~ group"

    maov = MANOVA.from_formula(formula, data=df)
    return maov.mv_test()

# Example usage:
# df1 = extract_vr_data(group1)
# df2 = extract_vr_data(group2)
# df3 = extract_vr_data(group3)
# df4 = extract_vr_data(group4)
# print(perform_manova(df1, df2, df3, df4))
