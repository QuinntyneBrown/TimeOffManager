import { Skill } from "./skill";

export type Employee = {
    employeeId: string,
    name: string,
    email: string,
    sixMonthReviewRequired?: boolean,
    hireDate: Date,
    skill: Skill
};
