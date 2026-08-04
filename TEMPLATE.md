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

Pass `-Verify:$false` to skip verification when calling via `powershell -File`.

## What the script does

1. Copies the engineering baseline (MSBuild, Cursor rules, GitHub templates).
2. Writes project `README.md` / `CONTRIBUTING.md` from `templates/*.project.md` (not the kit docs).
3. Scaffolds `src/` + `tests/` and a solution file.
4. Applies Library or App CI workflow.
5. Initializes git on `main` with Conventional Commits template.
6. Optionally verifies build and creates the GitHub remote.

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
