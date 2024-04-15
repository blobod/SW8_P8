# Setting Up #

Before you begin, please note that this repository uses Git Large File Storage (Git LFS) to handle large digital assets efficiently. You will need to set up Git LFS to correctly pull and push these files.

## Install Git LFS for macOS Users

You can install Git LFS by visiting the [Git LFS website](https://git-lfs.github.com/) or using Homebrew, a package manager for macOS.

### Using Homebrew:
  1. If you do not have Homebrew installed, [install it here](https://brew.sh/).
  2. Open a terminal.
  3. Run `brew install git-lfs`.
  4. Once installed, set up Git LFS in your repository with `git lfs install`.

## Pull Files Using Git LFS
  1. Open a terminal.
  2. Navigate to the directory of your repository.
  3. Run `git lfs pull` to download the large files.

### Verify Installation
  - You can verify that Git LFS is set up correctly by running `git lfs install`. It should confirm that the hooks are set up.

### Troubleshooting
  - If you encounter issues, ensure that Git LFS is properly installed and that you have internet connectivity. For more specific problems, consult the [Git LFS FAQ](https://github.com/git-lfs/git-lfs/wiki/FAQ).
