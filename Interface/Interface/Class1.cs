using System.Collections.Generic;
using System.ServiceModel;
using TypeDefine;

namespace Interface
{
	[ServiceContract]
	public interface IWcfInterface
	{
		
		/// <summary>
		/// 今の自分のステータスを取得します。
		/// </summary>
		/// <param name="id">自分のID</param>
		/// <returns>ステータス</returns>
		[OperationContract]
		Status GetMyStatus(string id);

		/// <summary>
		/// 現在一番上に出されているカード
		/// </summary>
		/// <returns>カードのリスト</returns>
		[OperationContract]
		List<Card> Layout();

		/// <summary>
		/// 最後に場札が流れたあと最初に出されたカード
		/// </summary>
		/// <returns>カードのリスト</returns>
		[OperationContract]
		List<Card> Lead();

		/// <summary>
		/// 最後に場札が流れてから今までに出されたカード
		/// </summary>
		/// <returns>indexが若いほど古いカードです。</returns>
		[OperationContract]
		List<List<Card>> TableCards();

		/// <summary>
		/// 今までに流れたカードのリスト
		/// </summary>
		/// <returns>indexが若いほど古いカードです。</returns>
		[OperationContract]
		List<List<Card>> Discards();



	}
}
