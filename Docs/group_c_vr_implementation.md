**# XR Rig Documentation for Meta Quest in Unity**

## Overview
An XR rig has been added to the project. It supports controller input and hand tracking for Meta Quest devices.

## Requirements
- **Unity Version:** 6000.031 
- **XR Interaction Toolkit**
- 
- **Meta XR SDK**
- **Meta Hand Tracking SDK** (Optional)
- **Oculus Integration Package**

## Setup Guide
1. Install **XR Interaction Toolkit** via Unity Package Manager.
2. Import **Oculus Integration Package** from the Unity Asset Store.
3. Enable **Oculus** in **XR Plug-in Management**.
4. Add the **XR Rig Prefab** to the scene.
5. Enable **Hand Tracking Support** in **Oculus Settings**.
6. Configure **XR Controller (Device-Based)** for input actions.

## Functionality
- **Controller Input:** Supports movement, grabbing, and UI interactions.
- **Hand Tracking:** Allows object interaction via hand gestures.
- **Locomotion:** Supports teleportation and continuous movement.

## Customization
- Modify hand-tracking gestures via **Oculus Hand Tracking Components**.
- Adjust interaction layers for objects.
- Customize hand-tracking visuals.

## Troubleshooting
**Hand tracking not working:**
- Enable it in Oculus settings.
- Check if **Meta XR Hands** is assigned.

**Controllers not tracking:**
- Ensure Oculus app and tracking are enabled.
- Restart the headset and Unity project.

**XR Rig not responding:**
- Check input bindings in **Input Action Manager**.
- Ensure **XR Interaction Toolkit** is set up correctly.

## Conclusion
The XR rig provides basic VR interaction with controllers and hand tracking on Meta Quest.

