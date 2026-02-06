//data is sent to the backend for login

export interface logindto{
    username:string
    password:string
}

//data is sent to the backend for the registration or sign up 

export interface registrationdto{
    username:string
    password:string
}

//data recieved from the backend after the login

export interface authresponse{
    token:string
    userid:number
    username:string
}

