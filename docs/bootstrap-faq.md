# Bootstrap FAQ (technical)

Operational process and “what to choose” live in the Notion **Playbook**. This file answers stable technical questions that travel with the kit.

## Library vs App

| | Library | App |
| - | ------- | --- |
| Scaffold | `classlib` | `console` (Worker uses App profile) |
| `IsPackable` | `true` in csproj | default `false` |
| Child CI | MyWorkflows + NuGet (`templates/ci.library.yml`) | local build/test (`templates/ci.app.yml`) |
| Publish | tags `v*` + `NUGET_API_KEY` | none |

Apps target a **Modular Monolith** (Domain / Application / Infrastructure / Host) by convention. The generator still scaffolds a flat console project; layers are added progressively (often Domain first). Full Modular Monolith scaffolding remains on the Notion **Roadmap**.

## Prerequisites

- .NET SDK matching `global.json`
- Optional: GitHub CLI (`gh`) for `-CreateGitHub`
- Optional: Cursor CLI for `-OpenCursor`
- Library CI on GitHub needs access to `sandre58/MyWorkflows` and secret `NUGET_API_KEY`

## What the generator excludes

See `forge.manifest.json` `excludeFromCopy` (includes `scripts/`, kit `docs/`, `templates/`, kit README/LICENSE, …).

## Project name validation

`-Name` must be a C# identifier: `^[A-Za-z_][A-Za-z0-9_]*$`.

## Public documentation language

Generated `README.md` / `CONTRIBUTING.md` (and contributor-facing docs) are **English**, including shields.io badges in the README template.

## Solution layout

Generated `.slnx` includes solution folders for projects and repo meta files (`/build/`, `/docs/`, `/github/`, `/cursor/rules/`). Project `.csproj` files stay slim: TFM / nullable / implicit usings come from `Directory.Build.props`.

## Test packages / xUnit

Test projects named `*Tests` get packages from `build/dependencies.props` (xUnit, FluentAssertions, Moq, coverlet, …).  
`Directory.Build.targets` copies `xunit.runner.visualstudio` adapters next to the test assembly (required for `dotnet test` discovery on modern SDKs).

## Local NuGet feed

Copy `Directory.Build.local.props.example` → `Directory.Build.local.props` (gitignored) when you need a private feed. See comments in the example file.

## GitVersion / packaging

- `GitVersion.yml` feeds MSBuild version properties when available.
- Packaging metadata applies when `IsPackable=true` via `build/package.props` + `build/repo.props`.
- `RepositoryUrl` is not hard-coded to Forge; children rely on tokenized `build/repo.props`.

## Updating a child after Forge changes

Manual for V1: copy the specific props/rules/workflow you need. Automated upgrade is on the Notion **Roadmap**.

## Decisions

Record structural decisions in the project’s Notion **Décisions** database — not in repo Markdown.
