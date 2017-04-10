using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using TypeDefine;

namespace InterfaceDefine
{
    public class InterfaceDefine : IWcfInterface
    {
	    /// <summary>
	    /// 今の自分のステータスを取得します。
	    /// </summary>
	    /// <param name="id">自分のID</param>
	    /// <returns>ステータス</returns>
	    public Status GetMyStatus(string id)
	    {
		    return Status.Wait;
	    }

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

	    /// <summary>
	    /// そのカードが出せるかどうか判定します。
	    /// </summary>
	    /// <param name="checkCards">出したいカード</param>
	    /// <returns>判定</returns>
	    [OperationContract]
	    bool CheckFollow(List<Card> checkCards);

	    /// <summary>
	    /// そのカードが出せるかどうか判定します。
	    /// </summary>
	    /// <param name="layout">現在の場札</param>
	    /// <param name="checkCards">出したいカード</param>
	    /// <returns>判定</returns>
	    [OperationContract]
	    bool CheckFollow(List<Card> layout, List<Card> checkCards);
    }
}
