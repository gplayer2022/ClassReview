# ClassReview

オブジェクト指向の基礎。

﻿
## プロジェクト作成手順

1. メニュー [ファイル] > [新規作成] > [プロジェクト] を選択
2. ウィンドウ [新しいプロジェクトの作成] で `Blazor WebAssembly スタンドアロン アプリ` を選択し、ボタン [次へ] を押下
3. ウィンドウ [新しいプロジェクトを構成します] でプロジェクト名・場所・ソリューション名を設定し、ボタン [次へ] を押下
4. ウィンドウ [追加情報] で、下記のように設定し、ボタン [作成] を押下
    - フレームワーク: `.NET 10.0`
    - 認証の種類: `なし`
    - HTTPS 用の構成: ☑
    - プログレッシブ Web アプリケーション: □
    - サンプルページを含める: □
    - 最上位レベルのステートメントを使用しない: ☑
    - .NET Aspire オーケストレーションへの傘下: □

表示先は [ClassReview](https://gplayer2022.github.io/ClassReview/) 。



## 設定手順

1. `.github/workflows/gh-pages.yml` を設定する
    - 必ずソリューションのルートからの相対パスで指定すること！
    - 1 字たりとても間違えないこと！
    - ただし、 `.yml` ファイル名については任意でよい
2. GitHub リポジトリで `Settings` > `Code` でブランチ切り替え用のドロップダウンから [View all branches] を選択する
3. GitHub リポジトリの、`Branches` でボタン [New branch] をクリックし、 `gh-pages` ブランチを作成する
4. GitHub リポジトリで `Settings` > `Pages` > `Branch` を `gh-pages` に設定する
5. GitHub リポジトリで `Settings` > `Actions` > `General` > `Workflow permissions` を `Read and write permissions` に設定する
6. Visual Studio でソリューションをコミットおよびプッシュする




## YAML ファイルの説明

```yml
name: Deploy Blazor WASM to GitHub Pages

on:
  push:
    branches: [ "master" ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v4

    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: 8.0.x

    - name: Publish
      run: dotnet publish -c Release -o release

    - name: Fix base href
      run: |
        sed -i 's|<base href="/" />|<base href="/ExBlazorWebAssembly/" />|g' release/wwwroot/index.html
        cp release/wwwroot/index.html release/wwwroot/404.html
        touch release/wwwroot/.nojekyll

    - name: Deploy
      uses: peaceiris/actions-gh-pages@v4
      with:
        github_token: ${{ secrets.GITHUB_TOKEN }}
        publish_dir: release/wwwroot
```


# ローカルで発行する

```cmd
dotnet publish -c Release -o release
```

- `publish` : 発行する
    - 他のサブコマンドの例
        - `build` : ビルドする
        - `run` : 実行する
- `-c Release` : Debug ではないく Release ビルドで発行する
- `-o release` : 発行先のフォルダを `release` にする
