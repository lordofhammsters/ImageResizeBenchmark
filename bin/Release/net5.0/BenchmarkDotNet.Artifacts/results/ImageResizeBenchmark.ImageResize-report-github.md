``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
Intel Core i5-4570 CPU 3.20GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


```
|              Method |     fileNameIn |     fileNameOut | width | height |        Mean |     Error |    StdDev |      Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |--------------- |---------------- |------ |------- |------------:|----------:|----------:|------------:|------:|------:|------:|----------:|
| **ResizeNetVipsQuant7** | **C:\Work\in.jpg** | **C:\Work\out.jpg** |   **300** |    **300** |    **50.79 ms** |  **0.968 ms** |  **1.225 ms** |    **50.62 ms** |     **-** |     **-** |     **-** |      **6 KB** |
|    ResizeNetVipsQ85 | C:\Work\in.jpg | C:\Work\out.jpg |   300 |    300 |    45.41 ms |  0.906 ms |  1.463 ms |    45.37 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\in.jpg | C:\Work\out.jpg |   300 |    300 |   121.85 ms |  1.365 ms |  1.140 ms |   121.65 ms |     - |     - |     - |      4 KB |
| **ResizeNetVipsQuant7** | **C:\Work\in.jpg** | **C:\Work\out.jpg** |   **700** |    **700** |   **102.01 ms** |  **1.082 ms** |  **0.959 ms** |   **101.98 ms** |     **-** |     **-** |     **-** |      **6 KB** |
|    ResizeNetVipsQ85 | C:\Work\in.jpg | C:\Work\out.jpg |   700 |    700 |    87.63 ms |  0.965 ms |  0.856 ms |    87.52 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\in.jpg | C:\Work\out.jpg |   700 |    700 |   161.23 ms |  3.054 ms |  6.029 ms |   158.75 ms |     - |     - |     - |      4 KB |
| **ResizeNetVipsQuant7** | **C:\Work\in.jpg** | **C:\Work\out.jpg** |  **1000** |   **1000** |   **179.21 ms** |  **2.188 ms** |  **1.827 ms** |   **178.52 ms** |     **-** |     **-** |     **-** |      **6 KB** |
|    ResizeNetVipsQ85 | C:\Work\in.jpg | C:\Work\out.jpg |  1000 |   1000 |   157.79 ms |  3.097 ms |  5.000 ms |   156.29 ms |     - |     - |     - |      6 KB |
| ResizeSystemDrawing | C:\Work\in.jpg | C:\Work\out.jpg |  1000 |   1000 |   193.81 ms |  1.056 ms |  0.882 ms |   193.63 ms |     - |     - |     - |      4 KB |
|    **ResizeNetVipsPng** | **C:\Work\in.png** | **C:\Work\out.png** |   **300** |    **300** |   **377.04 ms** |  **3.611 ms** |  **3.016 ms** |   **377.25 ms** |     **-** |     **-** |     **-** |      **4 KB** |
| ResizeSystemDrawing | C:\Work\in.png | C:\Work\out.png |   300 |    300 |    77.05 ms |  0.597 ms |  0.499 ms |    76.80 ms |     - |     - |     - |      4 KB |
|    **ResizeNetVipsPng** | **C:\Work\in.png** | **C:\Work\out.png** |   **700** |    **700** | **1,460.63 ms** | **28.956 ms** | **44.219 ms** | **1,438.61 ms** |     **-** |     **-** |     **-** |      **4 KB** |
| ResizeSystemDrawing | C:\Work\in.png | C:\Work\out.png |   700 |    700 |   120.25 ms |  1.559 ms |  1.458 ms |   120.04 ms |     - |     - |     - |      4 KB |
|    **ResizeNetVipsPng** | **C:\Work\in.png** | **C:\Work\out.png** |  **1000** |   **1000** | **2,326.49 ms** | **14.569 ms** | **13.628 ms** | **2,327.16 ms** |     **-** |     **-** |     **-** |      **4 KB** |
| ResizeSystemDrawing | C:\Work\in.png | C:\Work\out.png |  1000 |   1000 |   172.67 ms |  3.436 ms |  7.962 ms |   168.70 ms |     - |     - |     - |      4 KB |
