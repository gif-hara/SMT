# SMT

# 成果物
- https://gif-hara.itch.io/65535

# これはなに？
- [HKUIDocument](https://gist.github.com/gif-hara/5b9ce8e711eef1ae287ea3fe8cf3c600)のサンプルとして作られたゲーム。
- ゲーム自体はシンプルで、何かしらキー入力があったらカウンターが1加算されていき、0 ~ 65535のどれかの数値に達した時にゲーム終了となる。

# 肝となる部分
- HKUIDocumentを利用してUIの依存度を下げた作りが実現出来る点。
- ゲームのループ部分では単純なキー入力を行い、結果をHKUIDocument経由で反映させている。
