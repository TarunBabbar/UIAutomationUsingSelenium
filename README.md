# UIAutomationUsingSelenium

This project demonstrates UI automation using Selenium WebDriver with C#, MSTest, and FluentAssertions.

## Prerequisites
- .NET 8 SDK
- Chrome browser (for ChromeDriver)
- Visual Studio 2022 or later

## Running Tests in Parallel

### 1. Enable Parallel Test Execution
MSTest supports parallel test execution. To enable it, add the following to your `.runsettings` file (create one in the solution root if it doesn't exist):

```xml
<RunSettings>
  <RunConfiguration>
    <MaxCpuCount>0</MaxCpuCount> <!-- 0 uses all available cores -->
  </RunConfiguration>
  <MSTest>
    <Parallelize>
      <Workers>4</Workers> <!-- Number of parallel threads -->
      <Scope>ClassLevel</Scope> <!-- or MethodLevel -->
    </Parallelize>
  </MSTest>
</RunSettings>
```

- `Workers`: Number of parallel threads (adjust as needed).
- `Scope`: Use `ClassLevel` to run different test classes in parallel, or `MethodLevel` to run test methods in parallel.

### 2. Configure Visual Studio to Use .runsettings
- In Visual Studio, go to **Test > Configure Default Processor Architecture** and select your architecture.
- Go to **Test > Select Settings File...** and choose your `.runsettings` file.

### 3. Run Tests
- Open **Test Explorer** in Visual Studio.
- Click **Run All**. Tests will execute in parallel according to your settings.

### 4. Notes for Selenium Parallelization
- Ensure each test creates its own WebDriver instance (do not share drivers between tests).
- Avoid static/shared state in test classes.
- If using ChromeDriver, make sure your machine can handle multiple browser instances.

## References
- [MSTest Parallel Test Execution](https://learn.microsoft.com/en-us/dotnet/core/testing/parallel-test-execution)
- [Selenium Documentation](https://www.selenium.dev/documentation/)

---
Feel free to update this README with additional project-specific details.
