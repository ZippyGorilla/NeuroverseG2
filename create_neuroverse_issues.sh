#!/bin/bash

REPO="Ziforge/Neuroverse"

# Group task definitions
declare -a TASKS_A=(
  "Define perceptual attribute scales"
  "Build calibration logging system"
  "Implement ML profile prediction (pretrained)"
  "Apply adaptive envelope filters"
  "Enable profile blending between users"
  "Write ML model + perceptual docs"
  "Internal testing of ML accuracy"
  "Final write-up + dataset packaging"
)

declare -a TASKS_B=(
  "Research Unity audio filters (EQ, spatial)"
  "Design profile-based ambient zones"
  "Connect profile output to sound design"
  "Implement adaptive audio transitions"
  "Dynamic ambient mood system"
  "Write filter documentation + diagrams"
  "QA audio interactions with users"
  "Finalize audio mix & record demo"
)

declare -a TASKS_C=(
  "Set up XR rig and scenes"
  "Build calibration scene"
  "Trigger scene changes from profile"
  "Add proximity detection & feedback"
  "Polish interaction design"
  "Document scene flow + architecture"
  "Run internal playtests (record logs)"
  "Export Quest 3 build + test packaging"
)

# Create issues
for i in {0..7}; do
  week=$((i+1))

  gh issue create --repo $REPO --title "[Group A – Week $week] ${TASKS_A[$i]}" \
    --body "Owned by George and Anna (Group A)\n\n**Week $week Task:** ${TASKS_A[$i]}\n\nPlease document in \`/docs/group_a_calibration_filtering.md\`." \
    --label "group-a" --label "week-$week" --label "documentation"

  gh issue create --repo $REPO --title "[Group B – Week $week] ${TASKS_B[$i]}" \
    --body "Owned by Alex and Size (Group B)\n\n**Week $week Task:** ${TASKS_B[$i]}\n\nPlease document in \`/docs/group_b_audio_design.md\`." \
    --label "group-b" --label "week-$week" --label "documentation"

  gh issue create --repo $REPO --title "[Group C – Week $week] ${TASKS_C[$i]}" \
    --body "Owned by Adam and August (Group C)\n\n**Week $week Task:** ${TASKS_C[$i]}\n\nPlease document in \`/docs/group_c_vr_implementation.md\`." \
    --label "group-c" --label "week-$week" --label "documentation"

done

