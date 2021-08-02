Compare NetVips and SystemDrawing.

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
Intel Core i5-4570 CPU 3.20GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


|              Method |        fileNameIn |        fileNameOut | width | height |      Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |------------------ |------------------- |------ |------- |----------:|---------:|---------:|------:|------:|------:|----------:|
| ResizeNetVipsQuant7 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   300 |    300 |  48.30 ms | 0.850 ms | 0.795 ms |     - |     - |     - |      6 KB |
|    ResizeNetVipsQ85 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   300 |    300 |  45.08 ms | 0.885 ms | 1.297 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   300 |    300 | 125.35 ms | 2.489 ms | 2.328 ms |     - |     - |     - |      4 KB |

| ResizeNetVipsQuant7 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   700 |    700 | 102.17 ms | 2.016 ms | 1.886 ms |     - |     - |     - |      6 KB |
|    ResizeNetVipsQ85 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   700 |    700 |  89.14 ms | 1.281 ms | 1.136 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |   700 |    700 | 162.57 ms | 3.114 ms | 3.058 ms |     - |     - |     - |      4 KB |

| ResizeNetVipsQuant7 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |  1000 |   1000 | 183.95 ms | 3.645 ms | 4.198 ms |     - |     - |     - |      6 KB |
|    ResizeNetVipsQ85 | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |  1000 |   1000 | 157.36 ms | 3.101 ms | 5.008 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\jpgIn.jpg | C:\Work\jpgOut.jpg |  1000 |   1000 | 201.77 ms | 3.975 ms | 6.962 ms |     - |     - |     - |      4 KB |

|       ResizeNetVips | C:\Work\pngIn.png | C:\Work\pngOut.png |   300 |    300 |  56.49 ms | 1.081 ms | 1.245 ms |     - |     - |     - |      4 KB |
| ResizeSystemDrawing | C:\Work\pngIn.png | C:\Work\pngOut.png |   300 |    300 |  78.72 ms | 1.295 ms | 1.386 ms |     - |     - |     - |      4 KB |

|       ResizeNetVips | C:\Work\pngIn.png | C:\Work\pngOut.png |   700 |    700 |  57.77 ms | 0.873 ms | 0.817 ms |     - |     - |     - |      4 KB |
| ResizeSystemDrawing | C:\Work\pngIn.png | C:\Work\pngOut.png |   700 |    700 | 123.96 ms | 2.422 ms | 3.064 ms |     - |     - |     - |      4 KB |

|       ResizeNetVips | C:\Work\pngIn.png | C:\Work\pngOut.png |  1000 |   1000 |  93.22 ms | 0.627 ms | 0.555 ms |     - |     - |     - |      4 KB |
| ResizeSystemDrawing | C:\Work\pngIn.png | C:\Work\pngOut.png |  1000 |   1000 | 169.70 ms | 3.359 ms | 3.869 ms |     - |     - |     - |      7 KB |
