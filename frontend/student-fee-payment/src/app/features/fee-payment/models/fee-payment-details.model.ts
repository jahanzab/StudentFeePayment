import { Student } from "../../student/models/student.model"

export interface FeePaymentDetails {
    id : string
    feeAmount : number
    isPaid : boolean
    paidDate: Date
    feeYear : string
    student: Student
    remarks : string;
    createdDate: Date;
}
