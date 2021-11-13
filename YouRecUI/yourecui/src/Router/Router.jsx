import { Routes, Route } from 'react-router-dom';
import MyRecommends from '../Components/MyRecommends/MyRecommends';
import CreateRecommend from '../Components/CreateRecommend/CreateRecommend';
import NoMatch from '../Components/NoMatch/NoMatch';
import Layout from '../Components/Layout/Layout.jsx'
import RecommendsPage from '../Components/Recommends/RecommendsPage';
import LoginForm from '../Components/Login/LoginForm';

export default function Router() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route index path="/Recs" element={<RecommendsPage />} />
                <Route path="/MyRecs" element={<MyRecommends />} />
                <Route path="/CreateRec" element={<CreateRecommend />} />
                <Route path="/SignIn" element={<LoginForm />} />

                <Route path="*" element={<NoMatch />} />
            </Route>
        </Routes>
    );
}