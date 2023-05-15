import createGlobalState from 'react-create-global-state';

const USER_KEY = 'user';

const storageUser = localStorage.getItem(USER_KEY);

const initialState = storageUser ? JSON.parse(storageUser) : null;

const [_useGlobalUser, Provider] = createGlobalState(initialState);

function useGlobalUser() {
  const [_user, _setUser] = _useGlobalUser();

  function setUser(user) {
    _setUser(user);
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  function setRide(ride) {
    const { user, content } = ride;
    const newUser = { ..._user, [user]: content };
    setUser(newUser);
  }

  function getRide(userId) {
    return _user[userId];
  }

  return [_user, setUser, setRide, getRide];
}

export const GlobalUserProvider = Provider;

export default useGlobalUser;
