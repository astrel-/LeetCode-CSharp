#!/bin/bash

# Script to copy a C# problem file template and update class names
#
# This script takes a single parameter: a four‑digit integer (e.g. 0123 or 1234).
# It will copy `Problem0000.cs` to `ProblemNNNN.cs` where `NNNN` is the
# provided number, and then replace all occurrences of `Problem0000` in
# the new file with `ProblemNNNN`.
#
# Usage:
#   ./copy_problem_cs.sh 0123
#
# Notes:
# - The script checks that the argument is exactly four digits.
# - It also verifies that the source file `Problem0000.cs` exists.
# - On macOS (BSD sed), `sed -i ''` is used; on other systems `sed -i` is used.

set -e

## Ensure exactly one argument is provided
if [ "$#" -ne 1 ]; then
  echo "Usage: $0 <4‑digit number>" >&2
  exit 1
fi

TARGET="$1"

# Validate that TARGET is four digits
if ! [[ "$TARGET" =~ ^[0-9]{4}$ ]]; then
  echo "Error: The argument must be a four‑digit number (0000–9999)." >&2
  exit 1
fi

# Define source and destination file names
SRC_FILE="Problem0000.cs"
DEST_FILE="Problem${TARGET}.cs"

## Check if the source file exists
if [ ! -f "$SRC_FILE" ]; then
  echo "Error: Source file '$SRC_FILE' not found. Ensure it exists in the current directory." >&2
  exit 1
fi

## Copy the template file to the new destination
cp "$SRC_FILE" "$DEST_FILE"

## Replace occurrences of the old class name with the new class name in the new file
# Use BSD sed syntax on macOS and GNU sed syntax on other systems
if [[ "$OSTYPE" == "darwin"* ]]; then
  # macOS/BSD sed requires an empty string after -i to suppress backup
  sed -i '' "s/Problem0000/Problem${TARGET}/g" "$DEST_FILE"
else
  # On GNU systems, no backup suffix is needed
  sed -i "s/Problem0000/Problem${TARGET}/g" "$DEST_FILE"
fi

echo "Successfully created '$DEST_FILE' from '$SRC_FILE' and updated class names."