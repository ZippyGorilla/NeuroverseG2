# Neuroverse: Adaptive VR for Neurodivergent Empathy
[![Docs](https://img.shields.io/badge/wiki-Documentation-blue?logo=github)](https://github.com/Ziforge/Neuroverse/wiki)
[![Overleaf](https://img.shields.io/badge/View%20Thesis-Overleaf-brightgreen?logo=Overleaf&logoColor=white)](https://www.overleaf.com/read/nddwcrqrpbcs#c4cd87)
---
[![Weekly Timesheet](https://img.shields.io/badge/Open_This_Week's_Timesheet-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/blob/main/weekly_notes/week-13-timesheet.md)
[![📋 Neuroverse Sprint Board](https://img.shields.io/badge/Project%20Board-Neuroverse-green?style=for-the-badge)](https://github.com/users/Ziforge/projects/1/views/1)
[![🧠 Sensory Calibration Questionnaire](https://img.shields.io/badge/Questionnaire-%F0%9F%A7%A0-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/wiki/Sensory-Calibration-Questionnaire)
[![🛡️ GDPR Consent Form](https://img.shields.io/badge/GDPR%20Consent-View%20Policy-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/wiki/GDPR-Consent-Form)
> 🌍 A VR platform that adapts to individual sensory needs — connecting neurodivergent and neurotypical users through shared, empathetic interaction.

This project explores adaptive sensory filtering and profile blending in shared VR experiences between neurotypical and neurodivergent individuals. Built in Unity using C# and deployed on Meta Quest 3.

## 🧠 Features

- Sensory calibration and profile prediction using ML
- Real-time filtering (audio, visual, motion)
- Shared user blending engine
- GDPR-compliant anonymous data collection
- Modular Unity-based architecture

➡️ **[See Full Development Guide on GitHub Wiki](https://github.com/Ziforge/Neuroverse/wiki/Development-Setup-Guide)**


## 🔁 Flow Chart

```mermaid
flowchart TD
    A[Start VR Session] --> B[Consent + GDPR Notice]
    B --> C[Calibration Scene]
    C --> D[Passive Behavior Tracking]
    D --> E[ML Predicts Sensory Profile]
    E --> F{Is Other User Nearby?}
    F -- Yes --> G[Blend Sensory Profiles]
    F -- No --> H[Continue Solo Experience]
    G --> I[Adapt Environment]
    H --> I
    I --> J[Cooperative Task or Puzzle]
    J --> K[Post-Session Debrief]
    K --> L[Session Ends]
```


## 📂 Structure

- `docs/`: Academic LaTeX report and diagrams  
- `unity_project/`: Unity C# source files  
- `data/`: Anonymized datasets  
- `website/`: HTML files for recruitment and consent  

## 🧪 Run the Study

1. Clone the repo  
2. Open `unity_project/` in Unity 2022+  
3. Load the calibration or experience scenes  
4. Start testing on Meta Quest 3  

## 📜 License

Licensed under GPL-3.0 or MIT

## 👥 Contributing

See [Contributing Guide on the Wiki](https://github.com/Ziforge/Neuroverse/wiki/Contributing‐to‐Neuroverse)
