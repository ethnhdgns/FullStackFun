import { useEffect, useState } from "react";
import {bowler} from "./types/bowler"

function BowlerList () {
    const [bowlers, setBowlers] = useState<bowler[]>([]);

    useEffect(() => {
        const fetchBowler = async () => {
            const response = await fetch ('https://localhost:7000/api/Bowlers');
            const data = await response.json();
            setBowlers(data);
        };
        fetchBowler();
    }, []);


    return(
        <>
        <table>
                <thead>
                    <tr>
                        <th>Bowler Name</th>
                        <th>Team Name</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Zip</th>
                    </tr>
                </thead>
                <tbody>
                    {
                    bowlers.map((f) => (
                        <tr key={f.bowlerID}>
                            <td>{`${f.bowlerFirstName} ${f.bowlerMiddleInit || ''} ${f.bowlerLastName}`}</td>
                            <td>{f.teamID}</td>
                            <td>{f.bowlerAddress}</td>
                            <td>{f.bowlerCity}</td>
                            <td>{f.bowlerState}</td>
                            <td>{f.bowlerZip}</td>
                        </tr>
                    ))
                    }
                </tbody>
            </table>
        </>
    )
}
export default BowlerList;