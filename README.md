Compare NetVips and SystemDrawing.

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
Intel Core i5-4570 CPU 3.20GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


|              Method | fileNameIn | fileNameOut| width | height |      Mean | Allocated |
|-------------------- |----------- |----------- |------ |------- |----------:|----------:|
| ResizeNetVipsQuant7 |     in.jpg |    out.jpg |   300 |    300 |  48.30 ms |      6 KB |
|    ResizeNetVipsQ85 |     in.jpg |    out.jpg |   300 |    300 |  45.08 ms |      6 KB |
| ResizeSystemDrawing |     in.jpg |    out.jpg |   300 |    300 | 125.35 ms |      4 KB |
|                     |            |            |       |        |           |          -|
| ResizeNetVipsQuant7 |     in.jpg |    out.jpg |   700 |    700 | 102.17 ms |      6 KB |
|    ResizeNetVipsQ85 |     in.jpg |    out.jpg |   700 |    700 |  89.14 ms |      6 KB |
| ResizeSystemDrawing |     in.jpg |    out.jpg |   700 |    700 | 162.57 ms |      4 KB |
|                     |            |            |       |        |           |          -|
| ResizeNetVipsQuant7 |     in.jpg |    out.jpg |  1000 |   1000 | 183.95 ms |      6 KB |
|    ResizeNetVipsQ85 |     in.jpg |    out.jpg |  1000 |   1000 | 157.36 ms |      6 KB |
| ResizeSystemDrawing |     in.jpg |    out.jpg |  1000 |   1000 | 201.77 ms |      4 KB |
|                     |            |            |       |        |           |          -|
|       ResizeNetVips |     in.png |    out.png |   300 |    300 |  56.49 ms |      4 KB |
| ResizeSystemDrawing |     in.png |    out.png |   300 |    300 |  78.72 ms |      4 KB |
|                     |            |            |       |        |           |          -|
|       ResizeNetVips |     in.png |    out.png |   700 |    700 |  57.77 ms |      4 KB |
| ResizeSystemDrawing |     in.png |    out.png |   700 |    700 | 123.96 ms |      4 KB |
|                     |            |            |       |        |           |          -|
|       ResizeNetVips |     in.png |    out.png |  1000 |   1000 |  93.22 ms |      4 KB |
| ResizeSystemDrawing |     in.png |    out.png |  1000 |   1000 | 169.70 ms |      7 KB |
