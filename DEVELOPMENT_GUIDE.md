Development Setup Guide – Neuroverse

This guide outlines how to set up the Neuroverse VR project for development, testing, and machine learning integration. It supports both Unity development and machine learning model experimentation.

📦 Required Tools

Tool/Library

Version

Purpose

Unity Hub

Latest

Manage Unity versions and projects

Unity Editor

2022.3 LTS

Core development engine

Meta Quest Developer Hub

Latest

Deploy/debug on Meta Quest 3

Android SDK/NDK

Unity-included

Required for Android/Quest builds

Visual Studio 2022+

w/ Unity Workload

C# IDE with IntelliSense

Git & GitHub Desktop

Latest

Version control + GitHub integration

ML.NET

Latest

Lightweight .NET-based ML in Unity

TensorFlow Lite

2.x (Python)

For embedded ML models

Unity Barracuda

Latest

Run TFLite models in Unity

SciKit-Learn

1.x (Python)

Prototyping ML models

NumPy / Pandas

Latest

Data preprocessing for ML models

Node.js + Live Server

Latest

(Optional) Serve website locally

🧩 Setup Instructions

1. Unity Installation

Download Unity Hub

Install Unity 2022.3 LTS

Include: Android Build Support + SDK/NDK Tools + OpenJDK

Add Visual Studio with Unity workload if prompted

2. Clone the Repository

git clone https://github.com/Ziforge/Neuroverse.git
cd Neuroverse

Or use GitHub Desktop to clone and manage branches.

3. Open the Project in Unity

Launch Unity Hub

Add Neuroverse/unity_project/ as a new project

Open in Unity Editor

4. Set Up Meta Quest 3

Download Meta Quest Developer Hub

Enable Developer Mode on your headset (via Meta app)

Connect headset to your PC via USB

In Unity:

Go to Edit > Project Settings > XR Plug-in Management

Enable Oculus under Android

5. Run and Test

Open CalibrationScene or MainExperienceScene in Unity

Press Play in Editor

Or go to File > Build Settings, select Android, and Build & Run to Quest

🧠 Machine Learning Integration

✅ Supported ML Libraries

Library

Use Case

Language

ML.NET

Lightweight profile inference

C#/.NET

TensorFlow Lite

Embedded neural models

Python/Unity

Unity Barracuda

Run .tflite or ONNX in Unity

Unity (C#)

SciKit-Learn

Prototyping (e.g., decision trees)

Python

Keras + TFLite

Train and export lightweight models

Python

🔄 ML Workflow (Flexible Options)

Option A – ML.NET (C#)

Use ML.NET Model Builder in Visual Studio

Train models locally using behavioral features (gaze, motion, etc.)

Export .zip and use in Unity with custom loader

Option B – TensorFlow Lite + Barracuda

Use Keras to train .tflite model in Python

Convert with tf.lite.TFLiteConverter

Import into Unity and run with Unity Barracuda

Option C – SciKit-Learn for Prototyping

Train offline decision tree or SVM using pandas + sklearn

Convert to ONNX or export decision rules manually

Rebuild logic in C# for fast runtime inference

🧪 ML Feature Inputs

Example features for predicting sensory profiles:

Head rotation velocity

Gaze dwell duration

Controller button press intervals

Haptic feedback latency

Scene transition pacing

🌐 Serve the Recruitment Website Locally

cd website
npx live-server

Or upload to GitHub Pages, Netlify, or Vercel.

✅ Quick Developer Checklist



📂 Folder Overview

Neuroverse/
├── unity_project/       → Unity VR source
├── docs/                → LaTeX thesis, diagrams
├── data/                → Anonymized datasets
├── website/             → Participant portal
├── README.md
├── CONTRIBUTING.md
├── DEVELOPMENT_GUIDE.md ← (this file)

💬 Need Help?

Please open an issue on GitHub or contact the lead researcher.

Built to support inclusive, empathetic technology. 🌍💡

