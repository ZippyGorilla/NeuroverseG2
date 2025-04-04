## ✅ Key Achievements

### 1. LaTeX Thesis Document & Scientific Foundation
- Created a structured master’s-level academic document in Overleaf
- Integrated sections on:
  - Neurodivergent conditions (autism, ADHD, schizophrenia, bipolar disorder)
  - Sensory adaptation frameworks and empathy-based interaction
  - Methodology, adaptive filtering techniques, ethical compliance (GDPR)
- Included scientific references and citations throughout

---

### 2. GitHub Wiki Setup & Documentation Infrastructure
- Built a structured GitHub Wiki system:
  - Navigation sidebar, home page, and linked markdown pages
  - Pages for Unity architecture, ML model design, GDPR & consent, perceptual interface design, and group responsibilities
  - Weekly timesheet logging and visual reporting

---

### 3. Prototype Sensory Filtering System (Unity)
- Created an isolated prototype environment (`experimental/SensoryPrototype/`) with:
  - Adaptive C# scripts for visual, audio, motion, and haptic filtering
  - Slider-based UI for real-time adjustment using perceptual language (e.g. “Dim”, “Strong”, “Natural”)
  - Profile saving/loading via JSON
  - Fully documented integration approach in both code and markdown

---

### 4. Project Planning, Automation & Sprint Tracking
- Configured a full GitHub Sprint Board with:
  - Weekly columns (1–8), labels per team group, and automation scripts
  - CLI and GraphQL-based issue creation for task tracking and review
  - Synced planning templates and milestone organization with group collaboration

---

### 5. Time Tracking & Visual Analytics
- Created a flexible system for weekly time tracking:
  - Markdown timesheets per week
  - Python-based graph generation for cumulative effort and goal completion
  - Badges and visual summaries embedded in README and Wiki

---

### 6. Machine Learning Planning & Mock Data
- Designed behavioral input feature set for future ML models:
  - Inputs include gaze tracking, posture, head motion, haptic sensitivity, culture, gender, and sensory history
- Drafted mock JSON datasets for simulation and calibration
- Mapped out potential integration using ML.NET, TFLite, and Unity Barracuda

---

### 7. Group A – Calibration & Adaptive Filtering Methodology
- Defined initial workflow for passive user calibration via UI sliders and JSON persistence
- I
✅ Sprint Log

⸻

🛠️ Main Technical Contributions

🔁 Calibration System Expansion
• Refactored and finalized CalibrationLogger.cs:
• Captures real-time perceptual input with timestamps and context
• Maps values to user-friendly perceptual labels (e.g., “Muted”, “Natural”)
• Serializes into timestamped JSON files
• Honors GDPR consent toggle before any logging occurs
• Developed and implemented CalibrationLoader.cs:
• Automatically scans for calibration log files
• Populates Unity UI dropdown for user selection
• Reloads values into sliders and rehydrates session state

⸻

🧪 Research & Theoretical Development

📄 LaTeX Academic Report (Overleaf)
• Added two major new sections:
• 🧠 Embodied Movement Strategies for Neurodivergent Accessibility
• 🎛️ UI Paradigm for Neurodivergent Interaction: Wrist-Based Modular Menus
• Provided academic backing and references on:
• Teleportation vs. smooth locomotion
• Importance of proprioception, comfort zones, and reduced visual strain
• Menu ergonomics (e.g. Fallout-style Pip-Boy inspiration)
• Use of perceptual terms across sensory filters for improved inclusivity
• Integrated key sources:
• Kane et al. on accessibility in immersive interfaces
• Schwind et al. on VR locomotion and motion sickness mitigation
• Lindgren et al. on cognitive load and menu orientation in AR/VR

⸻

🔐 GDPR & Consent System
• Rewrote full GDPR form (Markdown + LaTeX) to reflect:
• Optionality of haptics, motion, visual/audio adaptation
• Clear statement of anonymized data handling
• Participant right to withdraw at any time
• Added opt-in toggle into the calibration logger with enforcement
