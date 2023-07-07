import { useState, useEffect } from "react";
import React from "react";
import axios from "axios";

export default function TraTable() {
    const [showing, setShowing] = useState(false);
    const [transactions, setTransactions] = useState([]);

    async function getTheActions() {
        try {
            const response = await axios.get('/api/Transactions');
            console.log(response);
            setTransactions(response.data);
        } catch (error) {
            console.log('no', error);
        }
    }

    useEffect(() => {getTheActions()}, []);

    return (
        <>
            <button onClick={() => setShowing(!showing)}>{showing ? "STAHP" : "show me da transacties"}</button>
            { showing &&
                <table>
                    <thead>
                        <tr className="pretty">
                            <th>id</th>
                            <th>description</th>
                            <th>time that is probably redundant</th>
                        </tr>
                    </thead>
                    <tbody>
                        `           {transactions.map(acty =>
                            <tr key={acty.id} className="christmas">
                                <td>👀{acty.id}</td>
                                <td>{acty.description}</td>
                                <td>{acty.time}</td>
                            </tr>)}`
                    </tbody>
                </table>
            }
        </>
    )
}