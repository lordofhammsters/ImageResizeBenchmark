``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
Intel Core i5-4570 CPU 3.20GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


```
|              Method |        fileNameIn |        fileNameOut | width | height |      Mean |    Error |   StdDev |
|-------------------- |------------------ |------------------- |------ |------- |----------:|---------:|---------:|
| **ResizeNetVipsQuant7** | **C:\Work\jpgIn.jpg** | **C:\Work\jpgOut.jpg** |   **300** |    **300** |  **37.70 ms** | **0.746 ms** | **0.732 ms** |
|    ResizeNetVipsQ90 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   300 |    300 |  37.62 ms | 0.528 ms | 0.468 ms |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   300 |    300 |  55.31 ms | 0.825 ms | 0.772 ms |
| **ResizeNetVipsQuant7** | **C:\Work\jpgIn.jpg** | **C:\Work\jpgOut.jpg** |   **700** |    **700** |  **73.92 ms** | **0.799 ms** | **0.708 ms** |
|    ResizeNetVipsQ90 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   700 |    700 |  96.72 ms | 1.865 ms | 1.915 ms |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   700 |    700 |  84.38 ms | 1.105 ms | 0.979 ms |
| **ResizeNetVipsQuant7** | **C:\Work\jpgIn.jpg** | **C:\Work\jpgOut.jpg** |  **1000** |   **1000** | **110.79 ms** | **2.211 ms** | **2.172 ms** |
|    ResizeNetVipsQ90 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |  1000 |   1000 | 150.08 ms | 2.628 ms | 2.458 ms |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |  1000 |   1000 | 119.91 ms | 1.122 ms | 0.995 ms |
