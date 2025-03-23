# Neuroverse: Adaptive VR for Neurodivergent Empathy

This project explores adaptive sensory filtering and profile blending in shared VR experiences between neurotypical and neurodivergent individuals. Built in Unity using C# and deployed on Meta Quest 3.

## 🧠 Features

- Sensory calibration and profile prediction using ML
- Real-time filtering (audio, visual, motion)
- Shared user blending engine
- GDPR-compliant anonymous data collection
- Modular Unity-based architecture

➡️ **[See Full Development Guide](docs/DEVELOPMENT_GUIDE.md)**

---

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



📂 Structure
	-	Docs/: Academic LaTeX report and diagrams
	-	unity_project/: Unity C# source files
	-	data/: Anonymized datasets
	-	website/: HTML files for recruitment and consent

🧪 Run the Study
	- 1.	Clone the repo
	- 2.	Open unity_project/ in Unity 2022+
	- 3.	Load the calibration or experience scenes
	- 4.	Start testing on Meta Quest 3

📜 License

Licensed under GPL-3.0 or MIT

👥 Contributing

See CONTRIBUTING.md
