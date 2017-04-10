Millionaire [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/D-Yam/Millionaire/master/LICENSE.md)
====

`Millionaire`は，日本のトランプカードゲーム「大富豪」(以下，大富豪)のAIプレイヤーを作成し，対戦させることによりAI技術を競うプロジェクトと，そのホストプログラムです。  
なお，どうやら大富豪と似たカードゲームを指す英語は`Poverty`らしいですが，これは大貧民を意味する語なので，日本語のイメージに近い`Millionaire`をここでは採用します。  

ここからは長いです。そのうちwikiに移動するかも。  
## ルールの説明
日本大富豪連盟による「連盟公式ルール」に則ることとする…としたいところだけど完全なる私見と独断により、以下のルールとします。  
第1ゲームの最初にカードを出すプレイヤー(以下、親)と、順番の決め方については、後述する。  

- ハート、クローバー、ダイヤ、スペードそれぞれA〜Kまでの13×4枚と、ジョーカー×2枚の計54枚を使用する。
- カードはホストプログラムによってシャッフルされ、各プレイヤーに配られる。
- 配られたカードを手札という。
- この時、各プレイヤーは自分以外の手札を見ることはできない。
- ただし、各プレイヤーが残り何枚の手札を持っているかは知ることができる。
- 一定のルール(後述)によって、各プレイヤーがカードを公開していくことを、出すと言い、出されたカードがスタックされていく場所を場という。
- 親から順に手札を場に出していき、すべての手札を出しきることを「あがり」という。
- ゲーム開始から、全プレイヤー-1のプレイヤーが「あがり」になるまでを1ゲームとする。
- 10ゲーム1セットとする。
- 5プレイヤー以上で行う際は、
  - 1番上がり:大富豪
  - 2番上がり:富豪
  - 最後から2番目:貧民
  - 最後:大貧民
  - 上記以外:平民
  
  とする。
- 4プレイヤー以下で行う際は、
  - 4プレイヤー:平民地位無し
  - 3プレイヤー:富豪、貧民地位無し
  - 2プレイヤー:富豪、平民、貧民地位無し
  
　とする。
- 各ゲーム終了毎に、
  - 大富豪:2ポイント
  - 富豪:1ポイント
  - 平民:0ポイント
  - 貧民:-1ポイント
  - 大貧民:-2ポイント
  
　を各プレイヤーのポイントに加算する。
- ただし、最終ゲームの地位は最終地位として、
  - 大富豪:10ポイント
  - 富豪:5ポイント
  - 平民:0ポイント
  - 貧民:-5ポイント
  - 大貧民:-10ポイント
  
　として加算する。(通常ポイントも加算する)
- また、第2ゲームからゲーム開始前に、
  - 大貧民は一番強いカードから順に2枚、大富豪に渡す
  - 大富豪は任意のカードを2枚、大貧民に渡す
  - 貧民は一番強いカードを1枚、富豪に渡す
  - 富豪は任意のカードを1枚、貧民に渡す
  
　という処理を行う。(処理はこの順番で行われる)
 - このカード交換を不正に行った場合、その時点でそのプレイヤーは手札をすべて公開した上で流し、そのゲームの成績は不正を行ったプレイヤーの人数にかかわらず、すべて大貧民とする。
- この場合、残ったプレイヤーの中で残ったプレイヤー+1の地位割り振りから大貧民を抜いたものを適用する。(最後まで「あがり」になれなかったプレイヤー:貧民)
- ただし、不正をしなかったプレイヤーが1人の場合はそのプレイヤーを大富豪とし、それ以外を大貧民とする。
- 不正をしなかったプレイヤーがいなかった場合、そのゲームは無効となり、カードの分配からやり直す。

- 各プレイヤーの順番(以下、ターン)で取ることができる選択肢は、
  - 手札を出す
  - パス
  
　の2つである。
- ただし、すでに「あがり」になったプレイヤーにターンは訪れないこととする。
- 「手札を出す」を選択する際、プレイヤーは、
  - 場に出ているカードと「出し方」が同じである
  - 場に出ているカードより「強い」こと
  
　を満たすカードのみ、出すことができる。
- 上記条件を満たすカードを持たない場合、「パス」しか選択することができない。
- 場に出ているカードを出したプレイヤー以外のプレイヤーが、ターンでそれぞれ「パス」を選択した場合、場のカードは廃棄され(以外、流れる)、ゲーム終了まで使うことはできない。
- 場のカードが流れた場合、流れる前に最後にカードを出したプレイヤーのターンとなり、いかなる「出し方」「強さ」のカードも出すことができる。
- あるプレイヤーが「あがり」になった際、そのプレイヤーが最後に出したカードは流れず、次のプレイヤーのターンになる。
- この場合、すべてのプレイヤーが「パス」を選択した際、場のカードは流れ、「あがり」になった次のプレイヤーのターンになる。この際もいかなる「出し方」「強さ」のカードも出すことができる。

- 「出し方」とは、一度のターンに出すカードの枚数のことで、1〜6枚の中から、ゲーム開始直後の親のターンと、場のカードが流れた直後のターンにプレイヤーが、自身が出すことのできる範囲で任意に設定することができる。
- ただし、一度に出すカードは同じ数字でなくてはいけない。
- ジョーカーは、ワイルドカードとして使用することによって同時に出されるカードと同じ数字になることができる。
- 「強さ」とは、カードの数字によって決まり、3が一番弱く、2が一番強い。(下から順に、3,4,5,6,7,8,9,10,J,Q,K,A,2)
- ジョーカーは、単体で使うことにより、2よりも強くなる。(第2ゲームからのカード交換では一番強いカードとして扱われる)

- 特別な効力を持つカードも存在し、以下のように処理される。
  - 8
  :「八切り」場に出された時点で場のカードを流し、8を出したプレイヤーのターンとなる
  - スペード3
  :「スペ3返し」場に出されたカードがジョーカー1枚だった場合、スペードの3をそれ以上に強いカードとして出すことができる。

- 特別な効力を持つ「出し方」も存在し、以下のように処理される。
  - 4枚以上
  :「革命」この「出し方」以降、もう一度「革命」が起きるまでカードの強さが逆になる。(ジョーカー単体、「スペ3返し」はこれに含まれない)

- 反則あがりは存在しない。

- 第1ゲームの親は、識別IDが一番若いプレイヤーとし、識別IDの辞書順でターンが回ってくることとする。
- 第2ゲームからは、大貧民から開始し、「あがり」が遅かった順とする。
- 大貧民が複数いる場合は、識別IDの辞書順とする。

<2017/04/08 ver1.0ルール制定>

## 技術的な仕様
JK大富豪電脳戦で使用するAIプログラム(以下，AI)は、Visual Studio環境のC#で作成することを基本としますが，大富豪ホストプログラムとの通信が可能であれば技術は問いません。  
AIはゲーム開始から終了までユーザー他，ホストプログラム以外との通信や入力なく，独立して動くものとします。
ホストプログラムとの通信はWCFを使用します。

### 提供するもの
完成したらルートに持ってくるか新たにディレクトリを作るかしますが，それまでの間は[名前]/[名前]/bin/debug/にあります。

- TypeDefine.dll
: 型の定義をしています。参照に追加して使用してください。
- Interface.dll
: WCFで提供するインターフェースです。参照に追加して使用してください。
- InterfaceDefine.dll
: インターフェースの定義ファイルです。クライアントを作成する際には使用しません。
- MillionaireHost
: ホストアプリケーション本体です。


## Author
[D-Yam](https://github.com/D-Yam)
