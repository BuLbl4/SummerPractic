import {useSelector} from "react-redux";
import UserPanel from "./UserPanel";

const ProfileMenu = ({userInfo, setActiveComponent}) => {
    const user = useSelector(state => state.auth.user);


    return (
        <>
            <div className="col-lg-3 col-md-3">
                <div className="dashboard-navbar">

                    <div className="d-user-avater">
                        <h4>{userInfo.name}</h4>
                    </div>

                    <div className="elso_syu77">

                    </div>
                    {user && <UserPanel setActiveComponent={setActiveComponent}/>
                    }
                </div>

            </div>

        </>
    );
};

export default ProfileMenu;