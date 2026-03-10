# Dream Dictionary (Blazor WASM)

A modern, high-performance **Myanmar Dream Dictionary** built with **Blazor WebAssembly** and **.NET 9.0**. This application features a sleek, shadcn-inspired interface and leverages **IndexedDB** for fast client-side searching and offline capabilities.

## 🚀 Key Features

- **Blazor WASM + .NET 9.0**: Leveraging the latest .NET performance improvements and features.
- **Tailwind CSS v4 (shadcn-inspired)**: A beautifully designed UI featuring a focus on accessibility and modern aesthetics.
- **IndexedDB Search**: Dream data is cached on the first render into the browser's IndexedDB, enabling near-instant search results and offline functionality.
- **PWA Ready**: Fully configured web manifest with SVG icons and a mobile-friendly 5-column grid layout for the Myanmar alphabet.
- **SVG Branding**: Custom-designed "Moon & Stars" branding used for favicons, headers, and meta tags, with colors seamlessly integrated into the Tailwind theme.

## 🛠️ Technology Stack

- **Core**: [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
- **Styling**: [Tailwind CSS v4](https://tailwindcss.com/)
- **Storage**: [IndexedDB](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API) via **JavaScript Interop**
- **Deployment**: [GitHub Actions](https://github.com/features/actions) targeting [Vercel](https://vercel.com/)

## 📂 Architecture Overview

### ⚙️ Services & logic
- **`Services/IndexedDbService.cs`**: C# service providing high-level wrapper functions for interacting with the client-side database.
- **`wwwroot/js/db.js`**: Core JavaScript logic responsible for initializing the database, bulk-importing JSON data, and performing fast text-based searches.

### 🎨 Styling
- **`Styles/app.css`**: The main Tailwind source file containing custom theme tokens and layout rules.
- **`tailwind.config.js`**: Configuration file that defines utility classes and ensures the CSS is compiled specifically for Razor components.

## 🛠️ Build and Development

### Running the Project Locally

1. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

2. **Build Tailwind CSS**:
   (Requires Node.js)
   ```bash
   cd BlazorWasm.DreamDictionary
   npm install
   npx @tailwindcss/cli -i Styles/app.css -o ./wwwroot/css/app.css
   ```

3. **Run the app**:
   ```bash
   dotnet watch
   ```

### Deployment Configuration

The project is configured for automated deployment via **GitHub Actions** ([deploy.yml](.github/workflows/deploy.yml)). The CI/CD pipeline:
1. Sets up the **.NET 9.0** environment.
2. Initializes **Node.js** and compiles the **Tailwind CSS**.
3. Publishes the WASM application to the `release` directory.
4. Deploys the static assets to **Vercel**.

## 🖋️ Author

- **Sann Lynn Htun**