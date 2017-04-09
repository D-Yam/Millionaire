using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeDefine
{
	/// <summary>
	/// プレイヤーの現在の状態を表します。
	/// </summary>
	enum Status
	{
		/// <summary>
		/// 現在プレイヤーのターンです。
		/// </summary>
		Turn,

		/// <summary>
		/// 現在プレイヤーのターンではありません。
		/// </summary>
		Wait,

		/// <summary>
		/// プレイヤーはすでにあがりました。
		/// </summary>
		GoUp,

		/// <summary>
		/// プレイヤーは棄権，もしくは反則負けをしています。
		/// </summary>
		Abstained
	}

	/// <summary>
	/// プレイヤー
	/// </summary>
	/// <remarks>初期化する際にIDを指定してください。</remarks>
	class Player
	{
		/// <summary>
		/// プレイヤーを示すIDです。他者と重複することは出来ません。
		/// </summary>
		public String ID { get; }

		/// <summary>
		/// プレイヤーの現在のステータス
		/// </summary>
		public Status Status { set; get; }

		/// <summary>
		/// プレイヤーの現在の手札
		/// </summary>
		public List<Card> Hand { set; get; }

		/// <summary>
		/// プレイヤーのIDを指定して初期化します。
		/// </summary>
		/// <param name="id">プレイヤーのIDです。</param>
		public Player(String id)
		{
			ID = id;
		}



	}

	/// <summary>
	/// トランプの数字(絵札を含む)です。
	/// </summary>
	enum Rank
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}

	/// <summary>
	/// トランプのスートです。
	/// </summary>
	enum Suit
	{
		Hearts,
		Clubs,
		Diamonds,
		Spades
	}

	/// <summary>
	/// トランプのカード
	/// </summary>
	class Card
	{
		public Suit Suit { set; get; }
		public Rank Rank { set; get; }


	}


}
