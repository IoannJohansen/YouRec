import { Routes, Route } from 'react-router-dom';
import MyRecommends from '../Components/MyRecommends/MyRecommends';
import Recommends from '../Components/Recommends/Recommends';
import CreateRecommend from '../Components/CreateRecommend/CreateRecommend';
import NoMatch from '../Components/NoMatch/NoMatch';
import Layout from '../Components/Layout/Layout.jsx'

export default function Router() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route index path="/Recs" element={<Recommends />} />
                <Route path="/MyRecs" element={<MyRecommends />} />
                <Route path="/CreateRec" element={<CreateRecommend />} />

                <Route path="*" element={<NoMatch />} />
            </Route>
        </Routes>
    );
}