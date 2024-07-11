import ConfirmEmail from "./ConfirmEmail";
import ProfileResetPassword from "./ProfileResetPassword";

const ProfileEditContainer = ({userInfo}) => {
    console.log(userInfo)
    return(
        <>
            <div className="col-lg-9 col-md-9 col-sm-12" style={{display: "block"}} >
                <div className="row justify-content-between" style={{marginTop: 100}}>
                    {userInfo && !userInfo.emailConfirm && <ConfirmEmail userInfo={userInfo}/>}
                </div>
                <div className="row">
                    {userInfo && userInfo.emailConfirm && <ProfileResetPassword/>}
                </div>
            </div>
        </>
    );
}

export default ProfileEditContainer;