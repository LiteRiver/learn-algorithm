module.exports = {
  branches: ['main'],
  ci: false,
  dryRun: false,
  plugins: [
    '@semantic-release/commit-analyzer',
    '@semantic-release/release-notes-generator',
    [
      "@semantic-release/changelog",
      {
        "changelogFile": 'docs/CHANGELOG.md'
      }
    ],
  ],
};