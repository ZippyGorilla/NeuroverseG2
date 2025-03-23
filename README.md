# Neuroverse: Adaptive VR for Neurodivergent Empathy

This project explores adaptive sensory filtering and profile blending in shared VR experiences between neurotypical and neurodivergent individuals. Built in Unity using C# and deployed on Meta Quest 3.

## 🧠 Features

- Sensory calibration and profile prediction using ML
- Real-time filtering (audio, visual, motion)
- Shared user blending engine
- GDPR-compliant anonymous data collection
- Modular Unity-based architecture

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

See [CONTRIBUTING.md](CONTRIBUTING.md)

##Flow Chart


```mermaid
flowchart TD
    A[Start VR Session] --> B[Calibration Scene]
    B --> C[Passive Behavior Tracking]
    C --> D[ML Model Predicts Sensory Profile]
    D --> E{User Nearby?}
    E -- Yes --> F[Blend Profiles]
    E -- No --> G[Continue Solo Experience]
    F --> H[Adapt Environment]
    G --> H[Adapt Environment]
    H --> I[Complete Task / Puzzle]
    I --> J[Post-Session Debrief]
    J --> K[Data Saved (Anonymized & GDPR)]
    K --> L[Session Ends]
```
