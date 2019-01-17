# Watermarker
Adds a random watermark to an image. 

Background color is randomized with 50% chance for it to be transparent.
Watermark position is randomized
Watermark rotation is randomized between -15.0 and 15 degrees
Watermark size is randomized.

This was created to help train a model on how to remove watermarks.

# Usage
Run it through the command prompt with 

```
Watermarker.exe Path WatermarkText
```

Leave WatermarkText empty for randomized text.

e.g.

```
Watermarker.exe C:\test.png ©3DProgrammer