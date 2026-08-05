# Bootstrap a project from Forge

## One command

```powershell
cd C:\Dev\Forge
.\scripts\new-project.ps1 -Name MyProject -Type Library
# or
.\scripts\new-project.ps1 -Name MyApp -Type App -Org sandre58
```

### Useful switches

| Switch | Default | Meaning |
| ------ | ------- | ------- |
| `-Type Library\|App` | Library | Packable NuGet vs application |
| `-Verify` | `$true` | `dotnet restore/build/test` after scaffold |
| `-CreateGitHub` | off | `gh repo create` + push |
| `-OpenCursor` | off | Open the new folder in Cursor |
| `-RepositoryUrl` | `https://github.com/{Org}/{Name}` | Written to `build/repo.props` |
| `-Org` | `sandre58` | Used in README badges and default URL |

Pass `-Verify:$false` to skip verification when calling via `powershell -File`.

`-Name` must be a valid C# identifier.

## What the script does

1. Loads kit-only excludes and template paths from `forge.manifest.json`.
2. Copies the engineering baseline (MSBuild, Cursor rules, GitHub templates) — **not** `scripts/`.
3. Writes project `README.md` / `CONTRIBUTING.md` / `LICENSE` / `.slnx` from `templates/` (English README with badges; solution folders for build/docs/github/cursor).
4. Scaffolds `src/` + `tests/` with slim csproj files.
5. Applies Library or App CI workflow.
6. Initializes git on `main` with Conventional Commits template.
7. Optionally verifies build and creates the GitHub remote.

Kit-only paths (not copied): see `forge.manifest.json` and [docs/how-it-works.md](docs/how-it-works.md).

## Verify the kit itself

```powershell
.\scripts\Verify-Forge.ps1
```

Builds and tests `samples/Smoke` via `Forge.slnx`.

## Governance

- Process / FAQ « que choisir » : Notion **Playbook** (projet Forge).
- Décisions structurantes : DB **Décisions** Notion (jamais dans Git).
- Carte fichiers / FAQ technique : [docs/how-it-works.md](docs/how-it-works.md), [docs/bootstrap-faq.md](docs/bootstrap-faq.md).
