# 📂 Windows File Monitoring Service

A robust Windows Service built with C# and .NET Framework that monitors a specific directory in real-time, processes new files by renaming them with a unique GUID, and moves them to a destination folder.

This project demonstrates core concepts of background processing, event-driven programming, and system automation.

---

# 🚀 Features

- **Real-time Monitoring:** Uses `FileSystemWatcher` to detect new files instantly.
- **Unique Identification:** Automatically renames processed files using GUIDs to prevent naming conflicts.
- **Dynamic Configuration:** All paths (Source, Destination, Logs) are managed via `App.config` for easy maintenance without code changes.
- **Detailed Logging:** Maintains a chronological log of all service activities (Starts, Stops, File Movements, and Errors).
- **Dual Mode Support:** Can run as a standard Windows Service or in Console Mode for easier debugging.

---

# 🛠️ Technical Stack

- **Language:** C#
- **Framework:** .NET Framework 4.x

## Key Classes

- `ServiceBase` (Service Lifecycle)
- `FileSystemWatcher` (Event Detection)
- `ConfigurationManager` (App Settings)
- `System.IO` (File Operations)

---

# 📁 Project Structure

- `NewFileMonitoringService.cs` → The core logic of the service.
- `Program.cs` → Entry point with logic to switch between Service and Console mode.
- `App.config` → Configuration file for folder paths.
- `ProjectInstaller.cs` → Setup for Windows Service installation.

---

# ⚙️ Configuration

Modify the `App.config` file to set your local paths:

```xml
<appSettings>
  <add key="SourceFolder" value="C:\MyData\Source" />
  <add key="DestinationFolder" value="C:\MyData\Destination" />
  <add key="LogFolder" value="C:\MyData\Logs" />
</appSettings>
    
```
# 📺 Demo & Testing

## Console Mode

Run the project directly from Visual Studio (`F5`) to see real-time log output.

## Service Mode

Build in `Release` mode and install using `InstallUtil.exe`.

## Action Flow

Drop any file into the `Source` folder  
➡️ Observe the console/log  
➡️ Find the renamed file in the `Destination` folder

# 📺 Video Of Project & Photos

sha256:<img width="1916" height="964" alt="image" src="https://github.com/user-attachments/assets/96221990-cd1b-48f6-bf19-a10b851f0232" />



