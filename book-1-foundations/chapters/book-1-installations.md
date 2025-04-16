# Foundations Installations

## Setting up a second computer
If you are using a different computer for server side than you did for front end (or setting up Windows with Bootcamp on your Mac), you will need to do all of the front end installations first. They can be found [here](https://github.com/nashville-software-school/client-side-mastery/blob/master/book-1-installations/chapters/GETTING_STARTED_WINDOWS_C_SHARP.md).
## .NET 8 SDK
The .NET SDK includes all of the command line tools you will need to build and run your .NET programs for the first part of the course. <br>
[Download it for Windows here](https://download.visualstudio.microsoft.com/download/pr/cb56b18a-e2a6-4f24-be1d-fc4f023c9cc8/be3822e20b990cf180bb94ea8fbc42fe/dotnet-sdk-8.0.101-win-x64.exe
) <br>
[Download it for M1/M2/M3/M4 Macs here](https://download.visualstudio.microsoft.com/download/pr/4d6fe60e-611f-4db0-8b03-fc15ee03ca7a/e24b834bd82a75fb2a50a59b8a27aed3/dotnet-sdk-8.0.101-osx-arm64.pkg) <br>
[Download it for Intel Macs here](https://download.visualstudio.microsoft.com/download/pr/3b11b408-68e1-4a8f-a0ad-55b21456c4f6/03819d38c79a9aa4fd806f8c7b64130d/dotnet-sdk-8.0.101-osx-x64.pkg
)<br>
When the download completes, run (open) the file downloaded by your browser and click `Install` when prompted to. 

Verify that the install has worked by opening a new terminal and running `dotnet --version`. You should see `8.0.101`, or something similar. If your terminal doesn't recognize the command, ask an instructor to help. 


## C# Extension for VS Code <a id="c-extension-setup"></a>
Microsoft now offers **two C# extensions** with overlapping names, which can cause confusion. Here’s how to choose the right one for bootcamp tutorials:

---

### **Option 1: Classic C# Extension (Recommended)**
**Why**: Generates `.vscode` config files automatically, aligns with tutorials.  
**How to Install**:

```bash
# Install the classic C# extension
code --install-extension ms-dotnettools.csharp
```

⚠️ **Marketplace Warning**:  
The marketplace description says "*We highly recommend using C# Dev Kit*" – **ignore this** for bootcamp work. The "classic" extension (ID: `ms-dotnettools.csharp`) is the one you want.

---

### **Option 2: C# Dev Kit (Not Recommended for Bootcamp)**  
**Why Avoid**:  
- Hides `.vscode` folder (configs are internal)  
- Changes debugging workflows (uses "Projects" tab instead of `launch.json`)  
- Often auto-installs itself if you follow Microsoft’s prompts  



## Manual Debug Setup
If you accidentally installed it:  
```bash
# Full cleanup (Dev Kit + dependencies)
code --uninstall-extension ms-dotnettools.csdevkit
code --uninstall-extension ms-dotnettools.vscode-dotnet-runtime
```

---

### **Post-Install Setup**  
After installing the classic extension:  
1. Open your C# project in VS Code  
2. Press `Ctrl+Shift+P` → Run **`.NET: Generate Assets for Build and Debug`**  
3. A `.vscode` folder will appear with `launch.json`/`tasks.json`  

🔍 **Verify Your Setup**:  
```bash
# Should show ONLY 'ms-dotnettools.csharp'
code --list-extensions | grep dotnettools
```

---

### **Why This Matters**  
Corporate tooling (C# Dev Kit) prioritizes "simplicity" over transparency. By reverting to the classic extension, you regain control over debugging configurations – critical for learning how .NET projects actually work under the hood.
