First, create a new alias

```
git config --global alias.coa "!git add -A && git commit -m"
```

This can then be used like this

```
git coa "A bunch of horrible changes"
```
