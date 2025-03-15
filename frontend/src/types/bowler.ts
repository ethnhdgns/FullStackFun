export type bowler = {
    bowlerID: number
    bowlerLastName: string
    bowlerFirstName: string
    bowlerMiddleInit: string
    bowlerAddress: string
    bowlerCity: string
    bowlerState: string
    bowlerZip: string
    bowlerPhoneNumber: string
    teamID: number
    team?: team; // This is the missing piece!

};

export type team = {
    teamID: number;
    teamName: string;
};