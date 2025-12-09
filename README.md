# ImdbProject

ImdbProject is a simple desktop application (WPF) for browsing and managing movie/TV title information. It provides a searchable list of titles, a favourites view, and basic settings to control app behavior.

## Key features

- Search and browse titles
- Title list view (`Views/TitleListPage.xaml`)
- Favourites management (`Views/FavouritesPage.xaml`)
- Basic application settings (`Views/SettingsPage.xaml`)
- Single-window desktop UI (`App.xaml`, `MainWindow.xaml`)

## Requirements

- .NET 9 SDK
- A Windows machine (WPF desktop UI)
- Visual Studio 2022/2023 or another IDE that supports .NET 9 and WPF

Optional:
- If the application uses an external movie data API, you may need an API key and network access. Check the settings page in the app for configuration options.

## Getting started

1. Clone the repository:

   ```bash
   git clone https://github.com/JamieWatton32/ImdbProject.git
   cd "ImdbProject"
   ```

2. Open the project in Visual Studio by double-clicking `ImdbProject.csproj` or open the solution in your preferred editor.

3. Build the project (Debug or Release) and run. In Visual Studio: `Build -> Build Solution`, then `Debug -> Start Debugging` or `Start Without Debugging`.

4. Configure any required settings from the in-app `Settings` page before using features that require external services (for example, API keys).

## Project structure (high level)

- `App.xaml` - application entry and resources
- `MainWindow.xaml` - main window shell that hosts pages
- `Views/TitleListPage.xaml` - UI for browsing/searching titles
- `Views/FavouritesPage.xaml` - UI for viewing and managing favourites
- `Views/SettingsPage.xaml` - UI for app settings

## Troubleshooting

- Ensure the .NET 9 SDK is installed and your IDE supports WPF/.NET desktop development.
- If network calls fail, verify your internet connection and any API keys configured in the settings.

## Contributing

Contributions are welcome. Create issues or pull requests against the repository. Keep changes focused and add brief descriptions to PRs.

## License

If this repository does not include a license file, please add one or consult the project owner to confirm licensing.
