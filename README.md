# Iron Software – C# Coding Challenge: OldPhonePad

This is my solution to the OldPhonePad coding challenge for the AI Software Engineer (Junior) role at Iron Software.

## What It Does

This code simulates how old mobile phones used to work: you’d press number keys multiple times to type letters. For example:
- Pressing `2` once = `'A'`, twice = `'B'`, three times = `'C'`
- To type `"CA"`, you’d press `"222 2"` — the space acts as a pause so it doesn’t become `"2222"` → `'A'`

The method also supports:
- `*` → deletes the last character (backspace)
- `#` → ends input immediately (everything after is ignored)

As stated in the challenge, every input ends with `#`.

## Examples

| Input | Output |
|------|--------|
| `"33#"` | `"E"` |
| `"227*#"` | `"B"` |
| `"4433555 555666#"` | `"HELLO"` |
| `"8 88777444666*664#"` | `"TURING"` |

I worked through the last one manually:
- `"8"` → T  
- `"88"` → U  *(2 presses on "TUV")*  
- `"777"` → R  
- `"444"` → I  
- `"666"` → O → so far: `"TURIO"`  
- `*` → delete last → `"TURI"`  
- `"66"` → N  
- `"4"` → G  
Final result: **`"TURING"`**

## How It Works

I process the input one character at a time:
- Keep track of which number is being pressed and how many times
- When the key changes (or we hit a space), convert the current sequence to a letter
- `*` removes the last character from the result — but first commits any pending key press
- Stop as soon as we see `#`

I used `StringBuilder` for efficiency since we’re building a string step by step.

## How to Run

You’ll need the [.NET SDK](https://dotnet.microsoft.com/download) (6 or higher).

From the project root:
```bash
dotnet test