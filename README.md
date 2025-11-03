# Iron Software – C# Coding Challenge: OldPhonePad

This repository contains my solution to the **OldPhonePad** coding challenge for the **AI Software Engineer (Junior)** role at Iron Software.

## Problem Overview

Simulate text input from an old mobile phone keypad using multi-tap logic:

- Digits `2`–`9` map to letters (e.g., `2` → A, B, C).
- Repeated presses cycle through letters: `"222"` → `'C'`.
- A **space** separates sequences on the same key: `"222 2"` → `"CA"`.
- `*` acts as **backspace** (deletes the last character).
- `#` is the **send key** — processing stops immediately at the first `#`.
- Input **always ends with `#`** (as per spec).

## Examples

| Input | Output |
|------|--------|
| `"33#"` | `"E"` |
| `"227*#"` | `"B"` |
| `"4433555 555666#"` | `"HELLO"` |
| `"8 88777444666*664#"` | `"TVRING"` |

> **Note**: The last example was computed as:
> - `"8"` → T  
> - `"88"` → V  
> - `"777"` → R  
> - `"444"` → I  
> - `"666"` → O → `"TVRIO"`  
> - `*` → delete → `"TVRI"`  
> - `"66"` → N  
> - `"4"` → G  
> → Final: **`"TVRING"`**

##  How to Run

This project uses **.NET 6+** and **xUnit** for testing.

### Prerequisites
- [.NET 6 SDK or higher](https://dotnet.microsoft.com/download)

### Build & Test
```bash
# Navigate to the repo root
cd iron-software-oldphonepad-challenge

# Run all tests
dotnet test