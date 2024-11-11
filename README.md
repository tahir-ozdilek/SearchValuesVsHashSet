I performed a performance comparison between the HashSet<string> and SearchValues<string> data structures using the BenchmarkDotNet package.

Result:

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.1906) (VMware)
Intel Xeon Gold 6330 CPU 2.00GHz, 2 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI [AttachedDebugger]
  DefaultJob : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


| Method                 | Mean       | Error    | StdDev   |
|----------------------- |-----------:|---------:|---------:|
| HashSetSearchTest      |   939.9 us | 18.55 us | 21.36 us |
| SearchValuesSearchTest | 1,642.0 us | 32.63 us | 45.74 us |
